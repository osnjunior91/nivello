import React, { useEffect, useState } from 'react';
import { Grid } from '@material-ui/core';

import { GetAuctionBidByCustomer } from "../../../services";
import { BidsTable } from './../../commom/';

function CustomerBids() {
    const [auctions, setAuctions] = useState([]);
    useEffect(() => {
        GetAuctionBidByCustomer()
            .then(({ data }) => {
                setAuctions(data.data);
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

                <Grid item xs={12} direction="row" justifyContent="center" alignItems="center">
                    <BidsTable bids={auctions} showProductLink={true} />
                </Grid>
            </Grid>
        </div>
    )
}

export default CustomerBids