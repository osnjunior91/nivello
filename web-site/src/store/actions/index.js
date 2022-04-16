import { SUCCESS_AUTHENTICATE } from '../actionsType';

const Authentication_Success = (curentUser) => {
    return {
        type: SUCCESS_AUTHENTICATE,
        curentUser
    }
}

export { Authentication_Success }