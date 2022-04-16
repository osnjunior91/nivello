import React, { useEffect, useState } from 'react';
import { Grid } from '@material-ui/core';

import { GetProducts } from "../../../services";

function CustomerBids() {
    const [products, setProducts] = useState([]);
    useEffect(() => {
        GetProducts()
            .then(({ data }) => {
                setProducts(data.data);
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

                {
                    products?.map(item => {

                        return (
                            <Grid item
                                xs={12 / products.length}
                                container
                                direction="column"
                                justifyContent="center"
                                alignItems="center"
                            >
                                <h1>item.id</h1>
                            </Grid>
                        )
                    })
                }
            </Grid>
        </div>
    )
}

export default CustomerBids