import axios from "Interceptor";


export function AddProduct(name,  description, quantity,price, image) {
  console.log(name,  description, quantity,price, image);
  return axios.post('http://localhost:5230/api/Product',{

        "name": name,
        "description": description,
        "quantity": quantity,
        "pricePerUnit": price,
        "basicImage": image
  });

} 

export function GetProducts(){
    return axios.get('')
}