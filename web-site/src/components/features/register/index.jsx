import React, { useState } from 'react';
import { Grid, TextField, Button } from '@material-ui/core';
import { useNavigate } from 'react-router-dom';
import { useDispatch } from 'react-redux';
import { Auth } from "../../../services";
import { Authentication_Success } from '../../../store/actions';
import { Link } from 'react-router-dom';


function Register() {
    const dispatch = useDispatch();
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [dateOfBirth, setBirthday] = useState(new Date('2014-08-18T21:11:54'));
    const navigate = useNavigate();
    const submitForm = () => {
        Auth({ email, password })
            .then(({ data }) => {
                dispatch(Authentication_Success({
                    token: data.data
                }));
                sessionStorage.setItem('token-auth', data.data);
                navigate('/products/list');
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
                    id="date"
                    label="Birthday"
                    type="date"
                    InputLabelProps={{
                        shrink: true,
                    }}
                    value={dateOfBirth}
                    variant="outlined"
                    onChange={(e) => setBirthday(e.target.value)}
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
                    disabled={!email || !password || name}
                    fullWidth
                    onClick={submitForm}
                    variant="contained"
                    color="primary"
                >
                    Registrar
                </Button>
            </Grid>
            <Grid
                item
                direction="row"
                justifyContent="center"
                alignItems="center"
            >
                <Link to={`/`}>
                    Fazer login
                </Link>
            </Grid>
        </Grid>
    )
}

export default Register