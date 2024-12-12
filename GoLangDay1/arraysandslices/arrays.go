package arraysandslices

import ("fmt" 
  		"slices")
		

func Demo() {
	var hobbies [4]string;
	hobbies = [4]string{"sposrs", "cooling", "reading", "boxing"}

	fmt.Println(hobbies)
	prices := [4] float64 {10,20,30}
	fmt.Println(prices[3]);

	//slices
	hobbiesSlices := hobbies[1:2];// ? range in slices is [1,10] -> 1 to 9 [1,10]
	fmt.Println(hobbiesSlices)

	//utility functions
	fmt.Println((len(hobbiesSlices)))
	fmt.Println(cap(hobbiesSlices))

	//dynamic arrays
	productPrices := [] int64 {10,20};
	fmt.Println(productPrices[2]);

	productPricesUpdated := append(productPrices,30);

	productPrices = append(productPrices, 30);
	fmt.Println(productPricesUpdated)
	fmt.Println(productPrices)

	for index :=0; index < len(productPricesUpdated);index++{
		fmt.Println((productPricesUpdated[index]));
	}

	slices.Sort(productPricesUpdated)
}