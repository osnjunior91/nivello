import { combineReducers } from 'redux';
import { SUCCESS_AUTHENTICATE } from '../actionsType';

const INITIAL_STATE = {
    curentUser: {
        token: '',
        isAdmin: false
    }
};

const SuccessAuthenticateReducer = (state = INITIAL_STATE, action) => {
    switch (action.type) {
        case SUCCESS_AUTHENTICATE:
            return { ...state, curentUser: action.curentUser }
        default:
            return state;
    }
}


export const Reducers = combineReducers({
    Auth: SuccessAuthenticateReducer
})

