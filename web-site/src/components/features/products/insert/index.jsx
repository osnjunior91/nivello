import React, { useState } from 'react';
import { Grid, Button, TextField } from '@material-ui/core';
import { useNavigate } from 'react-router-dom';
import { ProductPost } from "../../../../services";


function InsertProduct() {
    const [imagem, setImagem] = useState();
    const [name, setName] = useState('');
    const [price, setPrice] = useState(0);
    const navigate = useNavigate();
    const submitForm = () => {
        ProductPost({ name, price, imagem }).then(() => {
            alert('Produto criado com sucesso');
            navigate('/products/list');
        }).catch((error) => {
            alert(error.response.data.split('\r\n')[1]);
            console.log(error);
        })
    };
    return (
        <Grid
            container
            direction="column"
            justifyContent="center"
            alignItems="center"
            spacing={3}
        >
            <Grid
                item
                direction="row"
                justifyContent="center"
                alignItems="center"
            >
                <TextField
                    fullWidth
                    id="name"
                    label="Nome"
                    variant="outlined"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                />
            </Grid>
            <Grid
                item
                direction="row"
                justifyContent="center"
                alignItems="center"
            >
                <TextField
                    fullWidth
                    type="number"
                    id="value"
                    label="Valor"
                    variant="outlined"
                    value={price}
                    onChange={(e) => setPrice(e.target.value)}
                />
            </Grid>

            <Grid
                item
                direction="row"
                justifyContent="center"
                alignItems="center"
            >
                <input
                    id="file"
                    accept='image/apng, image/avif, image/gif, image/jpeg, image/png, image/svg+xml, image/webp'
                    multiple
                    type="file"
                    onChange={(e) => setImagem(e.target.files[0])}
                />
            </Grid>
            <Grid
                item
                direction="row"
                justifyContent="center"
                alignItems="center"
            >
                <Button disabled={!name || !price || !imagem} onClick={submitForm} fullWidth variant="contained" color="primary">
                    Carregar Arquivo
                </Button>
            </Grid>
        </Grid>
    )
}

export default InsertProduct