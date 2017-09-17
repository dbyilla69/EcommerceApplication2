export interface Product {
  Id: number;
  productName: string;
  details: string;
  unitPrice: number;
  unitInStock:number;
  category: {categoryId: number; categoryName: string};
  SubCategory: {subCategoryId: number; subCategoryName: string};
}
export interface SaveProduct {
  id: number;
  productName: string;
  details: string;
  unitPrice: number;
  unitsInStock:number;
  categoryId: number;
  subCategoryId: number;
}
export interface Category {
  Id: number;
 Name: string;

}