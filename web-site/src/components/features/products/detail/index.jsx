import React, { useEffect, useState } from 'react';
import { Grid, Button } from '@material-ui/core';
import { useParams } from 'react-router-dom'
import { useNavigate } from 'react-router-dom';
import { useSelector } from 'react-redux';
import { GetProductById, AuctionBid, ProductDelete } from "../../../../services";
import { ProductDetailComponent, BidsTable, BidDialog } from "../../../commom";

function DetailProduct() {
    const { id } = useParams();
    const { curentUser } = useSelector(state => state.Auth)
    const [product, setProduct] = useState([]);
    const [open, setOpen] = useState(false);
    const [bidAmount, setBidAmount] = useState(0);
    const navigate = useNavigate();

    const submitBid = () => {
        AuctionBid({
            'productId': id,
            'amount': bidAmount
        })
            .then(() => {
                alert("Seu lance foi registrado com sucesso!");
                navigate('/products/list');
            })
            .catch((error) => {
                alert(error.response.data.split('\r\n')[0]);
            });

    }

    const deleteProduct = () => {
        ProductDelete(id)
            .then(() => {
                alert("Produto excluido com sucesso!");
                navigate('/products/list');
            })
            .catch((error) => {
                alert(error.response.data.split('\r\n')[0]);
            });
    }

    useEffect(() => {
        GetProductById(id)
            .then(({ data }) => {
                setProduct(data.data);
                setBidAmount(data.data.price);
            })
            .catch((error) => {
                console.log(error);
            });
    }, []);
    return (
        <div>
            <Grid container xs={12} spacing={5} direction="row" justifyContent="center" alignItems="center">
                <Grid item xs={7} direction="row" justifyContent="center" alignItems="center">
                    <ProductDetailComponent product={product} />
                </Grid>
                <Grid item xs={8} direction="row" justifyContent="center" alignItems="center">

                    {
                        (curentUser.isAdmin)
                            ? <Button onClick={deleteProduct} fullWidth variant="contained" color="primary">
                                Finalizar este item
                            </Button>
                            : (!product.isDelete) ? <Button onClick={() => { setOpen(true) }} fullWidth variant="contained" color="primary">
                                Dar lance para esse produto
                            </Button> : null
                    }
                </Grid>
                <Grid item xs={12} direction="row" justifyContent="center" alignItems="center">
                    <BidsTable bids={product.bids} />
                </Grid>
            </Grid>
            <>
                <BidDialog
                    bidAmount={bidAmount}
                    setBidAmount={setBidAmount}
                    open={open}
                    setOpen={setOpen}
                    handleSubmit={submitBid}
                />
            </>
        </div>
    )
}

export default DetailProduct