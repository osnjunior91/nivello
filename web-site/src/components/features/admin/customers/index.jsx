import React, { useEffect, useState } from 'react';
import { Grid } from '@material-ui/core';


import { GetCustomersByName } from "../../../../services";

function ListCustomers() {
    const [customers, setCustomers] = useState([]);
    useEffect(() => {
        GetCustomersByName()
            .then(({ data }) => {
                setCustomers(data.data);
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
                    customers?.map(item => {
                        return (<h1>{item.name}</h1>)
                    })
                }
            </Grid>
        </div>
    )
}

export default ListCustomers