﻿import HttpStatus from 'http-status-codes';
import { BadRequestError, NotFoundError } from './reqest-error';


export async function createRequestResult(response, requestType) {
    if (response.ok) {
        if (requestType === RequestTypes.ContentExpected) {
            var result = await response.json();
        } else {
            var result = null;
        }

        return result;
    } else {
        if (response.status === HttpStatus.BAD_REQUEST) {
            throw new BadRequestError();
        } else if (response.status === HttpStatus.NOT_FOUND) {
            throw new NotFoundError();
        } else {
            throw new Error();
        }
    }
}

export const RequestTypes = {
    ContentExpected: 0,
    NoContentExpected: 1
}
