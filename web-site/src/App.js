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
          <Route path="products/list" element={<ListProducts />} />
          <Route path="products/:id" element={<DetailProduct />} />
          <Route path="upload"
            element={
              <PrivateRoutes>
              </PrivateRoutes>} />
        </Routes>
      </div>
    </div>
  );
}

export default App;
