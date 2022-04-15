import { SUCCESS_AUTHENTICATE } from '../actionsType';

const Authentication_Success = ({ token }) => {
    return {
        type: SUCCESS_AUTHENTICATE,
        token
    }
}

export { Authentication_Success }