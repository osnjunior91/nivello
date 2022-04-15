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
                        ByCoders
                    </Typography>
                    <div>
                        <Link className="link" to="/upload">
                            Carregar Arquivo
                        </Link>
                    </div>
                    <div>
                        <Link className="link" to="/transactions">
                            Visualizar dados
                        </Link>
                    </div>
                </Toolbar>
            </AppBar>
        </div>
    )
}

export default Menu