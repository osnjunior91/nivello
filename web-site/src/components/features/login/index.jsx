import React, { useState } from 'react';
import { Grid, TextField, Button } from '@material-ui/core';
import { useNavigate } from 'react-router-dom';
import { useDispatch } from 'react-redux';
import { Auth } from "../../../services";
import { Authentication_Success } from '../../../store/actions';

function Login() {
    const dispatch = useDispatch();
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();
    const submitForm = () => {
        Auth({ email, password })
            .then(({ data }) => {
                dispatch(Authentication_Success({
                    token: data
                }));
                sessionStorage.setItem('token-auth', data);
                navigate('/upload');
            })
            .catch((erro) => {
                alert('Falha no login');
                console.log(erro);
            });
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
                    id="email"
                    label="Email"
                    variant="outlined"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
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
                    type="password"
                    id="password"
                    label="Senha"
                    variant="outlined"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                />
            </Grid>
            <Grid
                item
                direction="row"
                justifyContent="center"
                alignItems="center"
            >
                <Button
                    disabled={!email || !password}
                    fullWidth
                    onClick={submitForm}
                    variant="contained"
                    color="primary"
                >
                    Login
                </Button>
            </Grid>
        </Grid>
    )
}

export default Login