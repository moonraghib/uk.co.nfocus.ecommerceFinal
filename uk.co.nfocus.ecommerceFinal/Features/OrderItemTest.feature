Feature: OrderItemTest
Login as a pre-registered user to a clothing website, select and purchase an 
item of clothing. Enter a coupon code to get a discount and make sure the total
is the correct amount, if it is then place an order and retrieve the order
number.



@CouponTest
Scenario Outline: Get a discount on a selected item
	Given I am logged in with <email> and <password>
	
	And I have selected an item
	When I have applied the coupon code
	Then I should recieve the discount
Examples:
	| email                        | password     |
	| "mamoon.raghib@nfocus.co.uk" | "Mamoon123!" |


@OrderNumberTest
Scenario Outline: Checking order number
	Given I have an item in my cart and logged in with <email> and <password>
	When I have checked out
	Then The order should appear in My Orders
Examples:
	| email                        | password     |
	| "mamoon.raghib@nfocus.co.uk" | "Mamoon123!" |

