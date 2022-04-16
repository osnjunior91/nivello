import React, { useEffect, useState } from 'react';
import { Grid } from '@material-ui/core';
import Fab from '@material-ui/core/Fab';
import { useSelector } from 'react-redux';
import { Link } from 'react-router-dom';

import { ImgMediaCard } from "../../../commom";
import { GetProducts } from "../../../../services";

function ListProducts() {
    const { curentUser } = useSelector(state => state.Auth)
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

                {
                    (curentUser.isAdmin)
                        ? <Grid item
                            xs={12}
                            container
                            direction="column"
                            justifyContent="flex-end"
                            alignItems="flex-end"
                        >
                            <Link to={`/products/insert`}>
                                <Fab color="primary" aria-label="add">
                                    <h1>+</h1>
                                </Fab>
                            </Link>
                        </Grid> : null
                }
            </Grid>
        </div>
    )
}

export default ListProducts