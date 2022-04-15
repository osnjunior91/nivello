import React from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';


export default function BidDialog(props) {
    const { open, setOpen, handleSubmit, bidAmount, setBidAmount } = props;

    const handleClose = () => {
        setOpen(false);
    };

    return (
        <div>
            <Dialog open={open} onClose={handleClose} aria-labelledby="form-dialog-title">
                <DialogTitle id="form-dialog-title">Realizar Lance</DialogTitle>
                <DialogContent>
                    <DialogContentText>
                        Insira o valor do seu lance usando "." para informar os centavos.
                    </DialogContentText>
                    <TextField
                        autoFocus
                        margin="dense"
                        id="bidAmount"
                        label="Valor do lance"
                        type="number"
                        fullWidth
                        value={bidAmount}
                        onChange={(e) => setBidAmount(e.target.value)}
                    />
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClose} color="primary">
                        Cancelar
                    </Button>
                    <Button onClick={handleSubmit} color="primary">
                        Realizar Lance
                    </Button>
                </DialogActions>
            </Dialog>
        </div>
    );
}