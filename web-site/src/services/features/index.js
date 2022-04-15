import { BycodersApi, BycodersApiFormData } from "../axios";

const GetProducts = () => {
    return BycodersApi.get('/product');
}

const UploadFile = (file) => {
    const formData = new FormData();
    formData.append('file', file);
    return BycodersApiFormData.post('/bulk/file/upload', formData);
}

const Auth = (login) => {
    return BycodersApi.post('/auth/login', login);
}

export { GetProducts, UploadFile, Auth }