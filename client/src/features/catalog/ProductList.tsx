import { Box } from '@mui/material';

import ProductCard from './ProductCard';

import type { Product } from "../../app/models/Product";
type props = {
  products: Product[];  
}

export default function ProductList({ products }: props) {  
  return (
    <Box sx={{display:'flex', flexWrap:'wrap', gap:3, justifyContent:'center'}}>
      {products.map(product => (
        <ProductCard key={product.id} product={product} />
      ))}   
    </Box>
  )
}