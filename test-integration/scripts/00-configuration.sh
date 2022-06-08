#!/bin/bash

set -e

RED='\033[0;31m'

#-------------------------------------------------------------------------------
# Git Configuration
#-------------------------------------------------------------------------------
git config --global user.name "test"
git config --global user.email "test@gmail.com"

if [[ $? -ne 0 ]]; then
  echo "${RED}FAILED CONFIGURATION"
  exit 1
fi