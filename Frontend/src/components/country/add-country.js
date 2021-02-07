import React, { useState } from 'react';

import Country from '../../services/models/country';
import Headline from './headline';
import * as CountryService from '../../services/country-service';
import ConfirmActionButton from '../general/confirm-action-button';
import { invalidInput, added, defaultErrorMessage } from '../general/message-box-messages';

export default function Add() {
    const [name, changeName] = useState();
    const [changeMessageBoxValue] = useState(null);

    async function onDataSave() {
        if (!name) {
            changeMessageBoxValue(invalidInput());
            return;
        }
        let newCountry = new Country(null, name);

        try {
            await CountryService.add(newCountry);
            changeMessageBoxValue(added());
        } catch (ex) {
            changeMessageBoxValue(defaultErrorMessage());
        }
    }
    
    return (
        <div className="list-item-action rounded editing">
            <Headline name="Adding country"/>

            <div className="adding-form">
                <div className="row">
                    <div className="col-12">
                        <div className="editing-params-form">
                            <div className="row">
                                <div className="form-item">
                                    <label htmlFor="country-name">Country name</label>
                                    <input
                                        id="country-name"
                                        type="text"
                                        onChange={(event) => changeName(event.target.value)}
                                        value={name}
                                    />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <ConfirmActionButton onClick={onDataSave} buttonContent="Add"/>
            </div>
        </div>
    );
}