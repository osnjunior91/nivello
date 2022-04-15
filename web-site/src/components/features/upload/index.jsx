import React, { useState } from 'react';
import { Grid, Button } from '@material-ui/core';
import { useNavigate } from 'react-router-dom';
import { UploadFile } from "../../../services";


function Upload() {
    const [file, setFile] = useState();
    const navigate = useNavigate();
    const submitForm = () => {
        UploadFile(file).then(() => {
            alert('Arquivo Carregado');
            navigate('/transactions');
        }).catch((error) => {
            alert('Falha ao carregar o arquivo')
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
                <input
                    id="file"
                    accept='.txt'
                    multiple
                    type="file"
                    onChange={(e) => setFile(e.target.files[0])}
                />
            </Grid>
            <Grid
                item
                direction="row"
                justifyContent="center"
                alignItems="center"
            >
                <Button disabled={!file} onClick={submitForm} fullWidth variant="contained" color="primary">
                    Carregar Arquivo
                </Button>
            </Grid>
        </Grid>
    )
}

export default Upload