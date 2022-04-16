import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Accordion from '@material-ui/core/Accordion';
import AccordionSummary from '@material-ui/core/AccordionSummary';
import AccordionDetails from '@material-ui/core/AccordionDetails';
import Typography from '@material-ui/core/Typography';
import BidsTable from './../product/bids';


const useStyles = makeStyles((theme) => ({
    root: {
        width: '100%',
    },
    heading: {
        fontSize: theme.typography.pxToRem(15),
        fontWeight: theme.typography.fontWeightRegular,
    },
}));

export default function CustomerAccordions(props) {
    const { customers } = props;
    const classes = useStyles();

    return (
        <div className={classes.root}>
            {
                customers?.map(item => {
                    return (
                        <Accordion>
                            <AccordionSummary
                                aria-controls="panel1a-content"
                                id="panel1a-header"
                            >
                                <Typography className={classes.heading}>{item.name} - Clique para expandir</Typography>
                            </AccordionSummary>
                            <AccordionDetails>
                                <BidsTable bids={item.bids} showProductLink={true} />
                            </AccordionDetails>
                        </Accordion>
                    )
                })
            }
        </div>
    );
}