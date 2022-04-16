import React from 'react';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import { Link } from 'react-router-dom';
import './style.css'

function Menu() {
    return (
        <div>
            <AppBar position="static">
                <Toolbar>
                    <Typography variant="h6">
                        Nivello
                    </Typography>
                    <div>
                        <Link className="link" to="/products/list">
                            Produtos
                        </Link>
                    </div>
                    <div>
                        <Link className="link" to="/bids/list">
                            Visualizar Lances
                        </Link>
                    </div>
                </Toolbar>
            </AppBar>
        </div>
    )
}

export default Menu