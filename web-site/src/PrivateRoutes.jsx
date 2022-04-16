import React from 'react'
import { Navigate } from 'react-router-dom'
import { useSelector } from 'react-redux'

export const PrivateRoutes = ({ children }) => {

    const { curentUser } = useSelector(state => state.Auth)
    const isAuthenticated = (curentUser.token.length > 0);

    if (isAuthenticated) {
        return children
    }

    return <Navigate to="/" />
}