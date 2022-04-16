import { BycodersApi, BycodersApiFormData } from "../axios";

const GetProducts = () => {
    return BycodersApi.get('/product');
}

const GetProductById = (id) => {
    return BycodersApi.get(`/product/${id}`);
}

const GetAuctionBidByCustomer = () => {
    return BycodersApi.get(`/auction/profile/bids`);
}

const AuctionBid = (bid) => {
    return BycodersApi.post(`/auction/bid`, bid);
}


const UploadFile = (file) => {
    const formData = new FormData();
    formData.append('file', file);
    return BycodersApiFormData.post('/bulk/file/upload', formData);
}

const Auth = (login) => {
    return BycodersApi.post('/auth/login', login);
}

const RegisterCustomer = (customer) => {
    return BycodersApi.post('/customer', customer);
}

export { GetProducts, GetProductById, UploadFile, Auth, AuctionBid, GetAuctionBidByCustomer, RegisterCustomer }