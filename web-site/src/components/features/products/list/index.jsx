import React, { useEffect, useState } from 'react';
import { Grid } from '@material-ui/core';

import { ImgMediaCard } from "../../../commom";
import { GetProducts } from "../../../../services";

function ListProducts() {
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
                                <ImgMediaCard item={item} />
                            </Grid>
                        )
                    })
                }
            </Grid>
        </div>
    )
}

export default ListProducts