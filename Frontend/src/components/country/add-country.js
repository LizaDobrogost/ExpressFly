import React, { useState } from 'react';

import Country from '../../services/models/country';
import Headline from './headline';

import * as CountryService from '../../services/country-service';
import { BadRequestError } from '../../services/reqest-error';
import ConfirmActionButton from '../general/confirm-action-button';
import {Dropdown, DropdownButton} from "react-bootstrap";

export default function Add() {
    const [name, changeName] = useState();

    async function onDataSave() {
        if (!name) {
            //Message
            return;
        }

        let newCountry = new Country(null, name);

        try {
            await CountryService.add(newCountry);
            //Message
        } catch (ex) {
            if (ex instanceof BadRequestError) {
                //Message
            } else {
                //Message
            }
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