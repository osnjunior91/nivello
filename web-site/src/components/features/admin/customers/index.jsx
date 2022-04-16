import React, { useEffect, useState } from 'react';
import { Grid, TextField, Button } from '@material-ui/core';


import { CustomerAccordions } from "../../../commom";
import { GetCustomersByName } from "../../../../services";

function ListCustomers() {
    const [customers, setCustomers] = useState([]);
    const [name, setName] = useState('');

    const submitForm = () => {
        GetCustomersByName(name)
            .then(({ data }) => {
                setCustomers(data.data);
            })
            .catch((error) => {
                console.log(error);
            });
    }

    useEffect(() => {
        submitForm();
    }, []);
    return (
        <div>
            <Grid
                xs={12}
                container
                direction="row"
                justifyContent="center"
                alignItems="center"
                spacing={6}
            >
                <Grid
                    item
                    container
                    spacing={2} xs={12}
                    direction="row"
                    justifyContent="center"
                    alignItems="center">
                    <Grid item xs={6}>
                        <TextField
                            fullWidth
                            id="name"
                            label="Nome"
                            variant="outlined"
                            value={name}
                            onChange={(e) => setName(e.target.value)}
                        />
                    </Grid>
                    <Grid item xs={6}>
                        <Button
                            fullWidth
                            onClick={submitForm}
                            variant="contained"
                            color="primary"
                        >
                            Pequisar por nome
                        </Button>
                    </Grid>
                </Grid>

                <Grid item>
                    <CustomerAccordions customers={customers} />
                </Grid>
            </Grid>
        </div>
    )
}

export default ListCustomers