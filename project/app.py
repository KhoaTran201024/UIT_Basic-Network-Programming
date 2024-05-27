from flask import Flask, request, jsonify, render_template
from flask_sqlalchemy import SQLAlchemy
from werkzeug.security import generate_password_hash, check_password_hash
from crypto_utils import generate_key_pair, encrypt_message, decrypt_message
from flask_socketio import SocketIO, send, emit

app = Flask(__name__)
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///users.db'
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False
db = SQLAlchemy(app)
socketio = SocketIO(app)

# (User model and routes go here)
class User(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    username = db.Column(db.String(150), unique=True, nullable=False)
    password = db.Column(db.String(150), nullable=False)
    private_key = db.Column(db.Text, nullable=False)
    public_key = db.Column(db.Text, nullable=False)
    
@app.before_request
def create_tables():
    db.create_all()

@app.route('/register', methods=['POST'])
def register():
    data = request.get_json()
    hashed_password = generate_password_hash(data['password'], method='pbkdf2:sha256')
    private_key, public_key = generate_key_pair()
    new_user = User(username=data['username'], password=hashed_password, private_key=private_key.decode(), public_key=public_key.decode())
    db.session.add(new_user)
    db.session.commit()
    return jsonify({'message': 'registered successfully'})

@app.route('/login', methods=['POST'])
def login():
    data = request.get_json()
    user = User.query.filter_by(username=data['username']).first()
    if not user or not check_password_hash(user.password, data['password']):
        return jsonify({'message': 'invalid credentials'}), 401
    return jsonify({'message': 'login successful'})

@socketio.on('message')
def handle_message(data):
    sender_username = data['username']
    message = data['message']
    
    # Encrypt the message for all other users
    users = User.query.filter(User.username != sender_username).all()
    encrypted_messages = {}
    for user in users:
        encrypted_message = encrypt_message(user.public_key, message)
        encrypted_messages[user.username] = encrypted_message
    
    emit('encrypted_message', {'messages': encrypted_messages}, broadcast=True)

@app.route('/')
def index():
    return render_template('index.html')

if __name__ == '__main__':
    socketio.run(app, debug=True)
