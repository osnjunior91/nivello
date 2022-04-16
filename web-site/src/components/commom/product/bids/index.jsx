import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import { Link } from 'react-router-dom';

const useStyles = makeStyles({
    table: {
        minWidth: 650,
    },
});

export default function BidsTable(props) {
    const classes = useStyles();
    const { bids, showProductLink } = props;
    return (
        <TableContainer component={Paper}>
            <Table className={classes.table} size="small" aria-label="a dense table">
                <TableHead>
                    <TableRow>
                        <TableCell>Usuario</TableCell>
                        <TableCell align="right">Produto</TableCell>
                        <TableCell align="right">Data</TableCell>
                        <TableCell align="right">Valor</TableCell>
                        <TableCell align="right">Maior lance ?</TableCell>
                        {
                            (showProductLink) ?
                                <TableCell align="right">Visualizar produto</TableCell> : null
                        }
                    </TableRow>
                </TableHead>
                <TableBody>
                    {bids?.map((row) => (
                        <TableRow key={row.id}>
                            <TableCell component="th" scope="row">
                                {row.customerId}
                            </TableCell>
                            <TableCell align="right">{row.productId}</TableCell>
                            <TableCell align="right">{row.createdAt}</TableCell>
                            <TableCell align="right">R$ {row.amount}</TableCell>
                            <TableCell align="right">{row.isActive ? "Sim" : "Nao"}</TableCell>
                            {
                                (showProductLink) ?
                                    <TableCell align="right">
                                        <Link to={`/products/${row.productId}`}>
                                            Ver produto
                                        </Link>
                                    </TableCell> : null
                            }

                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    );
}