import React, { useEffect, useState } from 'react';
import { Grid } from '@material-ui/core';
import { useNavigate } from 'react-router-dom';
import { useDispatch } from 'react-redux';

import { ImgMediaCard } from "../../../commom";
import { GetProducts } from "../../../../services";

function ListProducts() {
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const [transactions, setTransactions] = useState([]);
    useEffect(() => {
        GetProducts()
            .then(({ data }) => {
                console.log(data.items);
            })
            .catch((error) => {
                console.log(error);
            });
    }, []);
    return (
        <Grid
            container
            direction="column"
            justifyContent="center"
            alignItems="center"
            spacing={3}
        >
            <ImgMediaCard />
        </Grid>
    )
}

export default ListProducts