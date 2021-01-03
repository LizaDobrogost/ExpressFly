import * as config  from '../config.json';
import {createRequestResult, RequestTypes} from "./request";

export async function getById(id) {
    const response = await fetch(
        `${config.API_URL}/Countries/${id}`,
        {
            method: 'GET',
            mode: 'cors',
            headers:{
                'Content-Type': 'application/json',
            },
        }
    );

    return await createRequestResult(response, RequestTypes.ContentExpected);
}

export async function searchByName(nameFilter) {
    const response = await fetch(
        `${config.API_URL}/Countries?nameFilter=${encodeURIComponent(nameFilter)}`,
        {
            method: 'GET',
            mode: 'cors',
            headers:{
                'Content-Type': 'application/json',
            },
        }
    );

    return await createRequestResult(response, RequestTypes.ContentExpected);
}

export async function add(country) {
    const response = await fetch(
        `${config.API_URL}/Countries`,
        {
            method: 'POST',
            mode: 'cors',
            body: JSON.stringify(country),
            headers:{
                'Content-Type': 'application/json',
            },
        }
    );

    return createRequestResult(response, RequestTypes.ContentExpected);
}

export async function update(country) {
    const response = await fetch(
        `${config.API_URL}/Countries`,
        {
            method: 'PUT',
            mode: 'cors',
            body: JSON.stringify(country),
            headers:{
                'Content-Type': 'application/json',
            },
        }
    );

    return createRequestResult(response, RequestTypes.NoContentExpected);
}

