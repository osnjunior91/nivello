import { BycodersApi, BycodersApiFormData } from "../axios";

const GetTransactions = () => {
    return BycodersApi.get('/transaction/store/all');
}

const UploadFile = (file) => {
    const formData = new FormData();
    formData.append('file', file);
    return BycodersApiFormData.post('/bulk/file/upload', formData);
}

const Auth = (login) => {
    return BycodersApi.post('/auth/login', login);
}

export { GetTransactions, UploadFile, Auth }