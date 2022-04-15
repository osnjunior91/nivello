import React, { useEffect, useState } from 'react';
import { Grid } from '@material-ui/core';
import { useParams } from 'react-router-dom'

import { GetProducts } from "../../../../services";

function DetailProduct() {
    const { id } = useParams();
    const [product, setProduct] = useState([]);
    useEffect(() => {
        GetProducts()
            .then(({ data }) => {
                setProduct(data.data);
            })
            .catch((error) => {
                console.log(error);
            });
    }, []);
    return (
        <div>
            <Grid
                container
                direction="row"
                justifyContent="center"
                alignItems="center"
                spacing={5}
            >

                <h1>{id}</h1>
            </Grid>
        </div>
    )
}

export default DetailProduct