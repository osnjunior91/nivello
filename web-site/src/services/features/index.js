import { NivelloApi, NivelloApiFormData } from "../axios";

const GetProducts = () => {
    return NivelloApi.get('/product');
}

const GetProductById = (id) => {
    return NivelloApi.get(`/product/${id}`);
}

const GetAuctionBidByCustomer = () => {
    return NivelloApi.get(`/auction/profile/bids`);
}

const AuctionBid = (bid) => {
    return NivelloApi.post(`/auction/bid`, bid);
}


const ProductPost = (product) => {
    const formData = new FormData();
    formData.append('Name', product.name);
    formData.append('Price', product.price);
    formData.append('Imagem', product.imagem);
    return NivelloApiFormData.post('/product', formData);
}

const ProductDelete = (id) => {
    return NivelloApi.delete(`/product/${id}`);
}

const Auth = (login) => {
    return NivelloApi.post('/auth/login', login);
}

const RegisterCustomer = (customer) => {
    return NivelloApi.post('/customer', customer);
}

export { GetProducts, GetProductById, ProductPost, Auth, AuctionBid, GetAuctionBidByCustomer, RegisterCustomer, ProductDelete }