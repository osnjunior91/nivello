import { Route, Routes } from "react-router-dom";
import { Menu } from './components/commom';
import './App.css'
import { PrivateRoutes } from "./PrivateRoutes";
import { Login, ListProducts, DetailProduct, CustomerBids, Register, InsertProduct, ListCustomers } from './components/features';

function App() {
  return (
    <div className="app">
      <div>
        <Menu />
      </div>
      <div className="container" >
        <Routes>
          <Route path="/" element={<Login />} />
          <Route path="/register" element={<Register />} />
          <Route path="products/list"
            element={
              <PrivateRoutes>
                <ListProducts />
              </PrivateRoutes>
            }
          />
          <Route path="customers/list"
            element={
              <PrivateRoutes>
                <ListCustomers />
              </PrivateRoutes>
            }
          />
          <Route path="bids/list"
            element={
              <PrivateRoutes>
                <CustomerBids />
              </PrivateRoutes>
            }
          />
          <Route path="products/:id"
            element={
              <PrivateRoutes>
                <DetailProduct />
              </PrivateRoutes>
            }
          />
          <Route path="products/insert"
            element={
              <PrivateRoutes>
                <InsertProduct />
              </PrivateRoutes>
            }
          />
        </Routes>
      </div>
    </div>
  );
}

export default App;
