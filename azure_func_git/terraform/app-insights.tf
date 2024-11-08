resource "azurerm_application_insights" "main" {
  name = "tf-appinsights-${var.application_name}-${var.environment_name}"
  #location            = azurerm_resource_group.main.location
  location = var.location
  resource_group_name = azurerm_resource_group.main.name
  #resource_group_name = var.resource_group_name
  application_type    = "web"
}