import React, { useState } from 'react';
import './Login.css';
import medicalImage from '../src/medical.jpg';

function Login() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        // Handle login logic here
    }

    return (
        <div className="login-wrapper">
            <div className="login-container">
                <div className="login-form">
                    <h2>Login</h2>
                    <p>Doesn't have an account yet? <span className="signup-link">Sign Up</span></p>
                    <form onSubmit={handleSubmit}>
                        <div className="input-container">
                            <label>Email Address</label>
                            <input
                                type="email"
                                placeholder="Enter your email"
                                value={email}
                                onChange={(e) => setEmail(e.target.value)}
                            />
                        </div>
                        <div className="input-container">
                            <label>Password</label>
                            <input
                                type="password"
                                placeholder="Enter your password"
                                value={password}
                                onChange={(e) => setPassword(e.target.value)}
                            />
                        </div>
                        <div className="forgot-link">Forgot Password?</div>
                        <div className="checkbox-container">
                            <input type="checkbox" id="remember" />
                            <label htmlFor="remember">Remember me</label>
                        </div>
                        <button type="submit" className="login-button">Login</button>
                    </form>
                </div>
            </div>
            <div className="image-container">
            <img src={medicalImage} alt="Medical" />
            </div>
        </div>
    );
}

export default Login;
