import {
	Button,
	Card,
	CardActions,
	CardContent,
	CardMedia,
	Typography,
} from '@mui/material';

import type { Product } from "../../app/models/Product";

type props ={
    product: Product;
}

export default function ProductCard({ product }: props) {
  return (
    <Card elevation={3}   
        sx={{
            width: 280,
            borderRadius: 2,
            display: 'flex',
            flexDirection: 'column',
            justifyContent: 'space-between'
        }}      
        >
      <CardMedia sx={{height:240, backgroundSize:'cover'}}
        image={product.pictureUrl}
        title={product.name}
        />    
      <CardContent>
        <Typography gutterBottom  
            sx={{textTransform:'uppercase'}}
            variant="subtitle2">
          {product.name}
        </Typography>
        <Typography
            variant="h6" 
            sx={{color:'secondary.main'}}>
          ${(product.price/100).toFixed(2)}
        </Typography>
      </CardContent>
      <CardActions 
        sx={{justifyContent:'space-between'}}>
        <Button size="small">Add to Cart</Button>
        <Button size="small">View</Button>
      </CardActions>
    </Card>
  )
}