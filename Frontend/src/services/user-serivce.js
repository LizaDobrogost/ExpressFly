import User from './models/user';
import AuthTokenProvider from '../AuthTokenProvider';

import AccountRole from './models/role';

import * as config from '../config.json';
import { createRequestResult, RequestTypes } from "./request";

export async function login(user) {
    checkLogin(user);
    const response = await fetch(
        `${config.API_URL}/accounts/login`,
        {
            method: 'POST',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        }
    );
    const result = await createRequestResult(response, RequestTypes.ContentExpected);

    const token = result.token;
    AuthTokenProvider.saveToken(token);

    return new User(
        result.firstName,
        result.secondName,
        result.email,
        result.password,
        result.role
    );
}

export async function register(user) {
    const response = await fetch(
        `${config.API_URL}/accounts/register`,
        {
            method: 'POST',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        }
    );

    const result = await createRequestResult(response, RequestTypes.ContentExpected);

    const token = result.token;

    AuthTokenProvider.saveToken(token);

    return new User(
        result.firstName,
        result.secondName,
        result.email,
        result.password,
        result.role
    );
}

export function checkLogin(userInfo) {
    const token = AuthTokenProvider.getToken();

    if (!token || !userInfo) {
        return {authorized: false, admin: false};
    }

    return {authorized: true, admin: userInfo.role === AccountRole.Admin};
}
