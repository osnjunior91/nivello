import axios from 'axios';

const BycodersApi = axios.create({
    baseURL: "https://localhost:44308/api/v1",
    headers: {
        'Content-type': 'application/json',
        'Authorization': 'Bearer ' + sessionStorage.getItem('token-auth')
    }
});

const BycodersApiFormData = axios.create({
    baseURL: 'https://localhost:44373/api/v1',
    headers: {
        'Accept': 'application/json',
        'Content-Type': 'multipart/form-data',
        'Authorization': 'Bearer ' + sessionStorage.getItem('token-auth')
    }
});

export { BycodersApi, BycodersApiFormData }