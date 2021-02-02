import React, { useState } from 'react';
import * as UserService from '../../services/user-serivce'
import { withRouter } from 'react-router';
import { loggedInSuccessfully, badLoginData } from '../general/message-box-messages';
import MessageBox from '../general/message-box';

function SignIn() {

    const [email, changeEmail] = useState(null);
    const [password, changePassword] = useState(null);
    const [messageBoxValue, changeMessageBoxValue] = useState(null);

    async function onLogin(event) {
        event.preventDefault();
        if (!email || !password) {
            return;
        }

        try {
            await UserService.login({email: email, password: password});
            changeMessageBoxValue(loggedInSuccessfully());

        } catch (ex) {
            changeMessageBoxValue(badLoginData());
        }

    }

    function showMessageBox() {
        if (messageBoxValue) {
            return (
                <MessageBox
                    message={messageBoxValue}
                    hideFunc={changeMessageBoxValue}
                />
            );
        }
    }

    return (
        <main className="rounded">
            {showMessageBox()}
            <form onSubmit={onLogin}>
                <h3>Log in</h3>
                <div className="form-group">
                    <label>Email</label>
                    <input
                        className="form-control"
                        placeholder="Enter Email"
                        type="email"
                        value={email}
                        onChange={(event) => changeEmail(event.target.value)}
                        required
                    />
                </div>
                <div className="form-group">
                    <label>Password</label>
                    <input
                        className="form-control"
                        placeholder="Enter Password"
                        type="password"
                        value={password}
                        onChange={(event) => changePassword(event.target.value)}
                        required
                    />
                </div>
                <div className="form-group">
                    <div className="custom-control custom-checkbox">
                        <input type="checkbox" className="custom-control-input" id="customCheck1"/>
                        <label className="custom-control-label" htmlFor="customCheck1">Remember me</label>
                    </div>
                </div>
                <button type="submit" className="btn btn-dark btn-lg btn-block">Sign in</button>
                <p className="forgot-password text-right">
                    Forgot <a href="#">password?</a>
                </p>
            </form>
        </main>
    );
}

export default withRouter(SignIn);