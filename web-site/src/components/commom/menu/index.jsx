import React from 'react';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import { Link } from 'react-router-dom';
import { useSelector } from 'react-redux'
import './style.css'

function Menu() {
    const { curentUser } = useSelector(state => state.Auth)
    return (
        <div>
            <AppBar position="static">
                <Toolbar>
                    <Typography variant="h6">
                        Nivello
                    </Typography>
                    {
                        (curentUser.token.length > 0) ?
                            <>
                                <div>
                                    <Link className="link" to="/products/list">
                                        Produtos
                                    </Link>
                                </div>
                                <div>
                                    {
                                        (curentUser.isAdmin) ?
                                            <Link className="link" to="/bids/list">
                                                Visualizar Clientes
                                            </Link>
                                            : <Link className="link" to="/bids/list">
                                                Visualizar lances
                                            </Link>
                                    }

                                </div>
                            </> : null
                    }
                </Toolbar>
            </AppBar>
        </div>
    )
}

export default Menu