import React from 'react';
import { Grid } from '@material-ui/core';
import './index.css'

function ProductDetailComponent(props) {
    const { product } = props;
    return (
        <div>
            <Grid
                container
                direction="row"
                justifyContent="center"
                alignItems="center"
                spacing={1}
            >
                <Grid item xs={8} direction="row" justifyContent="center" alignItems="center">
                    <img className='img-detail' src={`data:image/png;base64, ${product.imagem}`} alt={product.id} />
                </Grid>
                <Grid item xs={4} direction="column" justifyContent="center" alignItems="center">
                    <Grid item xs={12} justifyContent="center" alignItems="center">
                        <h1>{product.name}</h1>
                    </Grid>
                    <Grid item xs={12} direction="column" justifyContent="center" alignItems="center">
                        <h3>Preco Inicial:  R$ {product.price}</h3>
                    </Grid>
                </Grid>
            </Grid>
        </div>
    )
}

export default ProductDetailComponent