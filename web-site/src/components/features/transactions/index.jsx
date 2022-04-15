import React, { useEffect, useState } from 'react'
import { Accordion, AccordionSummary, Typography, AccordionDetails } from '@material-ui/core'
import { TableDetail } from './../../commom';
import { GetTransactions } from "../../../services";

function TransactionsView() {
    const [transactions, setTransactions] = useState([]);
    useEffect(() => {
        GetTransactions()
            .then(({ data }) => {
                setTransactions(data.items);
            })
            .catch((error) => {
                console.log(error);
            });
    }, []);

    return (
        <div>
            {
                transactions?.map(item => {
                    return (
                        <Accordion style={{ width: '90vw' }}>
                            <AccordionSummary
                                aria-controls="transactions-content"
                                id="transactions-header"
                            >
                                <Typography>{item.storeName}</Typography>
                            </AccordionSummary>
                            <AccordionDetails>
                                <TableDetail item={item} />
                            </AccordionDetails>
                        </Accordion>
                    )
                })
            }
        </div>
    )
}

export default TransactionsView