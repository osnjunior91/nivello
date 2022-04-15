import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';

const useStyles = makeStyles({
    table: {
        minWidth: 700,
    },
});


export default function TableDetail(props) {
    const classes = useStyles();
    const { item } = props;
    return (
        <TableContainer component={Paper}>
            <Table className={classes.table} aria-label="spanning table">
                <TableHead>
                    <TableRow>
                        <TableCell>Tipo da transação</TableCell>
                        <TableCell align="right">Documento</TableCell>
                        <TableCell align="right">Data</TableCell>
                        <TableCell align="right">Número do cartão</TableCell>
                        <TableCell align="right">Responsavel</TableCell>
                        <TableCell align="right">Valor</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {item.transactions?.map((row) => (
                        <TableRow key={row.desc}>
                            <TableCell>{row.desc}</TableCell>
                            <TableCell align="right">{row.type.description}</TableCell>
                            <TableCell align="right">{row.personDocument}</TableCell>
                            <TableCell align="right">{row.date}</TableCell>
                            <TableCell align="right">{row.cardNumber}</TableCell>
                            <TableCell align="right">{row.storeManager}</TableCell>
                            <TableCell align="right">{row.value}</TableCell>
                        </TableRow>
                    ))}
                    <TableRow>
                        <TableCell colSpan={2}>Total</TableCell>
                        <TableCell align="right">{item.sum}</TableCell>
                    </TableRow>
                </TableBody>
            </Table>
        </TableContainer>
    );
}