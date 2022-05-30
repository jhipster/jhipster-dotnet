#!/bin/bash

set -e

RED='\033[0;31m'

#-------------------------------------------------------------------------------
# Run FORMATTING
#-------------------------------------------------------------------------------
dotnet format --verify-no-changes --severity error

if [[ $? -ne 0 ]]; then
  echo "${RED}FAILED FORMATTING"
  exit 1
fi