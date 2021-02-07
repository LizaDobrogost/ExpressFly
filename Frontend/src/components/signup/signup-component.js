import React, { useState } from 'react';
import { withRouter } from 'react-router';
import User from '../../services/models/user';
import * as UserService from '../../services/user-serivce'
import { invalidInput, defaultErrorMessage } from '../general/message-box-messages';
import MessageBox from '../general/message-box';

function SignUp() {

    const [name, changeName] = useState();
    const [surname, changeSurname] = useState();
    const [email, changeEmail] = useState();
    const [password, changePassword] = useState();
    const [confirmPassword, changeConfirmPassword] = useState();
    const [messageBoxValue, changeMessageBoxValue] = useState();

    async function register(event) {
        event.preventDefault();
        if (!name
            || !surname
            || !email
            || !password
            || !confirmPassword
        ) {
            changeMessageBoxValue(invalidInput());
        }

        if (password !== confirmPassword) {
            changeMessageBoxValue("Passwords do not match!");
            return;
        }
        const newUser = new User(
            name,
            surname,
            email,
            password
        );

        try {
            await UserService.register(newUser);
            changeMessageBoxValue("You have registered !");
        } catch (ex) {
            {
                changeMessageBoxValue(defaultErrorMessage());
            }
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
            <form onSubmit={register}>
                <h3>Register</h3>
                <div className="form-group">
                    <label>First name</label>
                    <input
                        className="form-control"
                        placeholder="Name"
                        onChange={(event) => changeName(event.target.value)}
                        required
                    />
                </div>
                <div className="form-group">
                    <label>Last name</label>
                    <input
                        className="form-control"
                        placeholder="Surname"
                        onChange={(event) => changeSurname(event.target.value)}
                        required
                    />
                </div>
                <div className="form-group">
                    <label>Email</label>
                    <input
                        className="form-control"
                        type="email"
                        placeholder="Email"
                        onChange={(event) => changeEmail(event.target.value)}
                        required
                    />
                </div>
                <div className="form-group">
                    <label>Password</label>
                    <input
                        className="form-control"
                        type="password"
                        placeholder="Password"
                        onChange={(event) => changePassword(event.target.value)}
                        pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}"
                        title="Must contain at least one number and one uppercase and lowercase letter, and at least 8 or more characters"
                        required
                    />
                </div>
                <div className="form-group">
                    <label>Confirm password</label>
                    <input
                        className="form-control"
                        type="password"
                        placeholder="Confirm password"
                        onChange={(event) => changeConfirmPassword(event.target.value)}
                    />
                </div>
                <button type="submit" className="btn btn-dark btn-lg btn-block">Sign up</button>
                <p className="forgot-password text-right">
                    Already registered <a href="#">log in?</a>
                </p>
            </form>
        </main>
    );
}

export default withRouter(SignUp);