import { Route, Routes } from "react-router-dom";
import { Menu } from './components/commom';
import './App.css'
import { PrivateRoutes } from "./PrivateRoutes";
import { Login, ListProducts, DetailProduct } from './components/features';

function App() {
  return (
    <div className="app">
      <div>
        <Menu />
      </div>
      <div className="container" >
        <Routes>
          <Route path="/" element={<Login />} />
          <Route path="products/list"
            element={
              <PrivateRoutes>
                <ListProducts />
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
        </Routes>
      </div>
    </div>
  );
}

export default App;
