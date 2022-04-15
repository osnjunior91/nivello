import React, { useEffect, useState } from 'react';
import { Grid, Button } from '@material-ui/core';
import { useParams } from 'react-router-dom'

import { GetProductById } from "../../../../services";
import { ProductDetailComponent, BidsTable, BidDialog } from "../../../commom";

function DetailProduct() {
    const { id } = useParams();
    const [product, setProduct] = useState([]);
    const [open, setOpen] = useState(false);
    const [bidAmount, setBidAmount] = useState(0);

    const submitBid = () => {
        alert(bidAmount);
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
                    <Button onClick={() => { setOpen(true) }} fullWidth variant="contained" color="primary">
                        Dar lance para esse produto
                    </Button>
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