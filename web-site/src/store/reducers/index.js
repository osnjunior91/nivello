import { combineReducers } from 'redux';
import { SUCCESS_AUTHENTICATE } from '../actionsType';

const INITIAL_STATE = {
    token: ''
};

const SuccessAuthenticateReducer = (state = INITIAL_STATE, action) => {
    switch (action.type) {
        case SUCCESS_AUTHENTICATE:
            return { ...state, token: action.token }
        default:
            return state;
    }
}


export const Reducers = combineReducers({
    Auth: SuccessAuthenticateReducer
})

