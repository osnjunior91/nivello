import axios from 'axios';

const baseUrl = "https://localhost:44308/api/v1";

const NivelloApi = axios.create({
    baseURL: baseUrl,
    headers: {
        'Content-type': 'application/json',
        'Authorization': 'Bearer ' + sessionStorage.getItem('token-auth')
    }
});

const NivelloApiFormData = axios.create({
    baseURL: baseUrl,
    headers: {
        'Accept': 'application/json',
        'Content-Type': 'multipart/form-data',
        'Authorization': 'Bearer ' + sessionStorage.getItem('token-auth')
    }
});

export { NivelloApi, NivelloApiFormData }